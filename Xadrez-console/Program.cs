using System;
using tabuleiro;

namespace Xadrez_console
{
	class Program
	{
		static void Main(string[] args)
		{
			Tabuleiro tabuleiro = new Tabuleiro(8, 8);
			Peca torre1 = new Torre(tabuleiro, Cor.Preto);
			Peca rei1 = new Rei(tabuleiro, Cor.Branco);
			tabuleiro.InserePeca(torre1, new Posicao(3, 4));
			tabuleiro.InserePeca(rei1, new Posicao(0, 0));
			Tela.ImprimeTabuleiro(tabuleiro);
		}
	}
}
