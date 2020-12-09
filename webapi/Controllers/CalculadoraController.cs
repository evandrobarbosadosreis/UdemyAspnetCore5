using System;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class Calculadora
    {
        public double Adicionar(double valor1, double valor2) => valor1 + valor2;
        public double Subtrair(double valor1, double valor2) => valor1 - valor2;
        public double Multiplicar(double valor1, double valor2) => valor1 * valor2;
        public double Dividir(double valor1, double valor2) => valor2 > 0 ? valor1 / valor2 : 0;
        public double Media(double valor1, double valor2) => valor1 + valor2 / 2;
        public double RaizQuadrada(double valor) => Math.Sqrt(valor);
    }

    public static class Resultado
    {
        public static object Formatar(double valor, double total) => new
        {
            valor = valor,
            total = total
        };

        public static object Formatar(double valor1, double valor2, double total) => new
        {
            valor1 = valor1,
            valor2 = valor2,
            total = total
        };
    }

    /// <summary>
    /// Exercício apresentado no curso de asp.net core
    /// para exemplificação dos conceitos mais básicos
    /// na implementação de uma webapi, tais como:
    /// - definição de controllers;
    /// - mapeamento de endpoints;
    /// - definição de verbos http;
    /// - aplicar restrição nos parâmetros de querystring;
    /// - etc.
    /// </summary>

    [Route("[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        private readonly Calculadora _calc;

        public CalculadoraController()
        {
            _calc = new Calculadora();
        }

        [HttpGet]
        [Route("adicao/{valor1:double}/{valor2:double}")]
        public IActionResult Adicao(double valor1, double valor2)
        {
            var resultado = _calc.Adicionar(
                valor1,
                valor2);
            var formatado = Resultado.Formatar(
                valor1,
                valor2,
                resultado);
            return Ok(formatado);
        }

        [HttpGet]
        [Route("media/{valor1:double}/{valor2:double}")]
        public IActionResult Media(double valor1, double valor2)
        {
            var resultado = _calc.Media(
                valor1,
                valor2);
            var formatado = Resultado.Formatar(
                valor1,
                valor2,
                resultado);
            return Ok(formatado);
        }        

        [HttpGet]
        [Route("subtracao/{valor1:double}/{valor2:double}")]
        public IActionResult Subtracao(double valor1, double valor2)
        {
            var resultado = _calc.Subtrair(
                valor1,
                valor2);
            var formatado = Resultado.Formatar(
                valor1,
                valor2,
                resultado);
            return Ok(formatado);
        }

        [HttpGet]
        [Route("multiplicacao/{valor1:double}/{valor2:double}")]
        public IActionResult Multiplicacao(double valor1, double valor2)
        {
            var resultado = _calc.Multiplicar(
                valor1,
                valor2);
            var formatado = Resultado.Formatar(
                valor1,
                valor2,
                resultado);
            return Ok(formatado);
        }

        [HttpGet]
        [Route("divisao/{valor1:double}/{valor2:double}")]
        public IActionResult Divisao(double valor1, double valor2)
        {
            var resultado = _calc.Dividir(
                valor1,
                valor2);
            var formatado = Resultado.Formatar(
                valor1,
                valor2,
                resultado);
            return Ok(formatado);
        }

        [HttpGet]
        [Route("raiz-quadrada/{valor:double}")]
        public IActionResult Soma(double valor)
        {
            var resultado = _calc.RaizQuadrada(valor);
            var formatado = Resultado.Formatar(
                valor,
                resultado);
            return Ok(formatado);
        }
    }
}