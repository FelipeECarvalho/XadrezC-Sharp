using tabuleiro;
using System;

namespace Xadrez_console
{
	class Tela
	{
		public static void ImprimeTabuleiro(Tabuleiro tabuleiro)
		{
			for (int i = 0; i < tabuleiro.Linhas; i++)
			{
				Console.Write(tabuleiro.Linhas - i + "  ");
				for (int j = 0; j < tabuleiro.Colunas; j++)
				{
					ImprimirPecas(tabuleiro.GetPeca(i, j));

				}
				Console.WriteLine();
			}
			Console.Write("   ");
			for (int i = (int)'a'; i < (tabuleiro.Colunas + 'a'); i++)
			{
				Console.Write($" {(char)i} ");
			}
		}

		public static void ImprimeTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
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
					ImprimirPecas(tabuleiro.GetPeca(i, j));
					Console.BackgroundColor = fundoOriginal;
				}
				Console.WriteLine();
			}
			Console.Write("   ");
			for (int i = (int)'a'; i < (tabuleiro.Colunas + 'a'); i++)
			{
				Console.Write($" {(char)i} ");
			}
			Console.WriteLine();
		}


		public static void ImprimirPecas(Peca peca)
		{
			if (peca != null)
			{
				if (peca.Cor == Cor.Branco)
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
				Console.Write(" - ");
		}
	}
}
