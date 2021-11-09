using tabuleiro;
using System;

namespace Xadrez
{
	class PosicaoXadrez : Posicao
	{
		public PosicaoXadrez(char coluna, int linha) 
		{
			Linha = linha;
			Coluna = coluna;

		}

		public static PosicaoXadrez LerPosicaoXadrez() 
		{
			string posicao = Console.ReadLine();
			char coluna = posicao[0];
			int linha = int.Parse(posicao[1..]);
			return new PosicaoXadrez(coluna, linha);
		}

		public Posicao ConvertePosicao() 
		{
			return new Posicao(8 - Linha, Coluna - 'a');
		}
	}
}
