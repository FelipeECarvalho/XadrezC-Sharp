using System;
using tabuleiro;

namespace Xadrez_console
{
	class Program
	{
		static void Main(string[] args)
		{
			PosicaoXadrez posicao = new PosicaoXadrez('c', 7);
			Console.WriteLine(posicao.ConvertePosicao());
		}
	}
}
