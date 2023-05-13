using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaGUI
{
    public class Forca
    {
        public string PalavraParcial
        {
            get { return new string(letrasEncontradas); }
        }

        public int Erros
        {
            get { return erros; }
        }
        public int QuantLetra
        {
            get { return palavraSecreta.Length; }
        }

        public string mensagemFinal;

        private string palavraSecreta;
        private char[] letrasEncontradas;
        private int erros;

        public Forca()
        {
            mensagemFinal = "";
            palavraSecreta = ObterPalavraSecreta();
            letrasEncontradas = PopularLetrasEncontradas(palavraSecreta.Length);

            erros = 0;
        }

        public bool JogadorAcertou(char palpite)
        {
            bool letraFoiEncontrada = false;

            for (int i = 0; i < palavraSecreta.Length; i++)
            {
                if (palpite == palavraSecreta[i])
                {
                    letrasEncontradas[i] = palpite;
                    letraFoiEncontrada = true;
                }
            }

            if (letraFoiEncontrada == false)
                erros++;

            bool jogadorAcertou = new string(letrasEncontradas) == palavraSecreta;

            if (jogadorAcertou)
                mensagemFinal = $"Você acertou a palavra {palavraSecreta}, parabéns!";

            else if (JogadorPerdeu())
                mensagemFinal = "Você perdeu! Tente novamente...";

            return jogadorAcertou;
        }

        public bool JogadorPerdeu()
        {
            return erros == 6;
        }

        private string ObterPalavraSecreta()
        {
            string[] palavras = {
                "ABACATE",
                "ABACAXI",
                "ACEROLA",
                "ACAI",
                "ARACA",
                "ABACATE",
                "BACABA",
                "BACURI",
                "BANANA",
                "CAJA",
                "CAJU",
                "CARAMBOLA",
                "CUPUACU",
                "GRAVIOLA",
                "GOIABA",
                "JABUTICABA",
                "JENIPAPO",
                "MACA",
                "MANGABA",
                "MANGA",
                "MARACUJA",
                "MURICI",
                "PEQUI",
                "PITANGA",
                "PITAYA",
                "SAPOTI",
                "TANGERINA",
                "UMBU",
                "UVA",
                "UVAIA"
            };

            int indiceAleatorio = new Random().Next(palavras.Length);

            return palavras[indiceAleatorio];
        }

        private char[] PopularLetrasEncontradas(int tamanho)
        {
            char[] letrasEncontradas = new char[tamanho];

            for (int carectere = 0; carectere < letrasEncontradas.Length; carectere++)
                letrasEncontradas[carectere] = '_';

            return letrasEncontradas;
        }
    }
}
