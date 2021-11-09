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
				Console.Write(tabuleiro.Linhas - i + " ");
				for (int j = 0; j < tabuleiro.Colunas; j++) 
				{
					if (tabuleiro.GetPeca(i, j) != null)
					{
						if (tabuleiro.GetPeca(i, j).Cor == Cor.Branco)
						{
							Console.Write($" {tabuleiro.GetPeca(i, j)} ");
						}
						else 
						{
							ConsoleColor aux = Console.ForegroundColor;
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write($" {tabuleiro.GetPeca(i, j)} ");
							Console.ForegroundColor = aux;
						}
					}
					else 
					{
						Console.Write(" - ");
					}
				}
				System.Console.WriteLine();
			}
			Console.Write("  ");
			for (int i = (int)'a'; i < (tabuleiro.Colunas + 'a'); i++) 
			{
				Console.Write($" {(char)i} ");
			}
			Console.WriteLine();
		}
	}
}
