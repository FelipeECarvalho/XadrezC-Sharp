using System;
using tabuleiro;
using Xadrez;

namespace Xadrez_console
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Tabuleiro tab = new Tabuleiro(8, 8);

				Peca torre = new Torre(tab, Cor.Branco);
				Peca rei = new Rei(tab, Cor.Preto);

				Peca torre1 = new Torre(tab, Cor.Branco);
				Peca rei1 = new Rei(tab, Cor.Preto);

				Peca torre2 = new Torre(tab, Cor.Branco);
				Peca rei2 = new Rei(tab, Cor.Preto);

				tab.InserePeca(rei, new Posicao(3, 1));
				tab.InserePeca(torre, new Posicao(4, 2));

				tab.InserePeca(rei1, new Posicao(3, 3));
				tab.InserePeca(torre1, new Posicao(0, 4));

				tab.InserePeca(rei2, new Posicao(2, 5));
				tab.InserePeca(torre2, new Posicao(4, 6));

				Tela.ImprimeTabuleiro(tab);
			}
			catch (TabuleiroExceptions e) 
			{
				Console.WriteLine("ERROR: " + e.Message);
			}
		}
	}
}
