using tabuleiro;

namespace Xadrez
{
	class Cavalo : Peca
	{

		public Cavalo() 
		{
		}

		public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) 
		{	
		}

		private bool ValidaMovimento(Posicao pos)
		{
			Peca peca = Tabuleiro.GetPeca(pos);
			return peca == null || peca.Cor != Cor;
		}


		public override bool[,] MovimentosPossiveis()
		{
			Posicao pos = new Posicao(0, 0);
			bool[,] jogadasValidas = new bool[8, 8];

			// ESQUERDA
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna - 2);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna - 2);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			pos.TestarValores(Posicao.Linha - 2, Posicao.Coluna - 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			pos.TestarValores(Posicao.Linha + 2, Posicao.Coluna - 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// DIREITA

			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna + 2);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			pos.TestarValores(Posicao.Linha - 2, Posicao.Coluna + 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			pos.TestarValores(Posicao.Linha + 2, Posicao.Coluna + 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna + 2);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			return jogadasValidas;
		}

		public override string ToString()
		{
			return "C";
		}
	}
}
