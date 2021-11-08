using System;
using tabuleiro;

namespace Xadrez_console
{
	class Program
	{
		static void Main(string[] args)
		{
				Tabuleiro tabuleiro = new Tabuleiro(8, 8);
				Peca torre = new Torre(tabuleiro, Cor.Preto);
				Peca rei = new Rei(tabuleiro, Cor.Branco);
				Peca torre1 = new Torre(tabuleiro, Cor.Branco);
			try
			{
				tabuleiro.InserePeca(torre, new Posicao(0, 0));
				tabuleiro.InserePeca(rei, new Posicao(1, 2));
				tabuleiro.InserePeca(torre1, new Posicao(0, 0));
				Tela.ImprimeTabuleiro(tabuleiro);
			}
			catch (TabuleiroExceptions e) 
			{
				Console.WriteLine("ERRO: " + e.Message);
			}
		}
	}
}
