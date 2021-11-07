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
				for (int j = 0; j < tabuleiro.Colunas; j++) 
				{
					if (tabuleiro.Peca(i, j) != null)
					{
						Console.Write($" {tabuleiro.Peca(i, j)} ");
					}
					else 
					{
						Console.Write(" - ");
					}
				}
				System.Console.WriteLine();
			}
		}
	}
}
