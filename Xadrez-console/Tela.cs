﻿using tabuleiro;
using Xadrez;
using System;
using System.Collections.Generic;

namespace Xadrez_console
{
	class Tela
	{
		public static void ImprimirInformacaoDeJogoXadrez(PartidaDeXadrez partida)
		{
			ImprimirTabuleiro(partida.Tabuleiro);
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Turno: " + partida.Turno);
			if (!partida.Terminada)
			{
				Console.WriteLine("Aguardando a jogada das " + (partida.JogadorAtual).ToString() + "s");
				Console.WriteLine();
				ImprimirPecasCapturadasXadrez(partida);
				if (partida.Xeque)
					Console.WriteLine("XEQUE!");
			}
			else
			{
				Console.WriteLine("XEQUEMATE!");
				Console.WriteLine("VITÓRIA DAS " + partida.JogadorAtual.ToString().ToUpper() + "S");
			}
		}


		public static void ImprimirPecasCapturadasXadrez(PartidaDeXadrez partida)
		{
			Console.WriteLine("Pecas capturadas: ");
			Console.Write($"Brancas: ");
			ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
			Console.Write("Pretas: ");
			ConsoleColor aux = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;
			ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
			Console.ForegroundColor = aux;

		}

		private static void ImprimirConjunto(HashSet<Peca> conjunto)
		{
			Console.Write("[");
			foreach (Peca capturada in conjunto)
			{
				Console.Write(capturada + " ");
			}
			Console.WriteLine("]");

		}

		public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
		{
			for (int i = 0; i < tabuleiro.Linhas; i++)
			{
				Console.Write(tabuleiro.Linhas - i + "  ");
				for (int j = 0; j < tabuleiro.Colunas; j++)
				{
					tabuleiro.GetPeca(i, j);

				}
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.Write("   ");
			for (int i = (int)'a'; i < (tabuleiro.Colunas + 'a'); i++)
			{
				Console.Write($" {(char)i} ");
			}
			Console.WriteLine();
		}

		public static void ImprimirTabuleiroXadrez(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
		{
			ConsoleColor fundoOriginal = Console.BackgroundColor;
			ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
			for (int i = 0; i < tabuleiro.Linhas; i++)
			{
				Console.Write(tabuleiro.Linhas - i + "  ");
				for (int j = 0; j < tabuleiro.Colunas; j++)
				{
					if (posicoesPossiveis[i, j])
						Console.BackgroundColor = fundoAlterado;
					else
						Console.BackgroundColor = fundoOriginal;
					ImprimirPecasXadrez(tabuleiro.GetPeca(i, j));
					Console.BackgroundColor = fundoOriginal;
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.Write("   ");
			for (int i = (int)'a'; i < (tabuleiro.Colunas + 'a'); i++)
			{
				Console.Write($" {(char)i} ");
			}
			Console.WriteLine();
		}


		public static void ImprimirPecasXadrez(Peca peca)
		{
			if (peca != null)
			{
				if (peca.Cor == Cor.Branca)
					Console.Write($" {peca} ");
				else
				{
					ConsoleColor aux = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write($" {peca} ");
					Console.ForegroundColor = aux;
				}
			}
			else
			{
				Console.Write(" - ");
			}
		}
	}
}
