using tabuleiro;

namespace Xadrez
{
	class Rei : Peca
	{
		public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
		{
		}


		private bool ValidaMovimento(Posicao pos)
		{
			Peca peca = Tabuleiro.GetPeca(pos);
			return peca == null || peca.Cor != Cor;
		}


		public override bool[,] MovimentosPossiveis()
		{
			bool[,] jogadasValidas = new bool[8, 8];
			Posicao pos = new Posicao(0, 0);

			// Cima
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;


			// Baixo
			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;


			// Direita
			pos.TestarValores(Posicao.Linha, Posicao.Coluna + 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// Esquerda
			pos.TestarValores(Posicao.Linha, Posicao.Coluna - 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// NE
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna + 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// SE
			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna + 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// SO
			pos.TestarValores(Posicao.Linha + 1, Posicao.Coluna - 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			// NO
			pos.TestarValores(Posicao.Linha - 1, Posicao.Coluna - 1);
			if (Tabuleiro.VerificaPosicao(pos) && ValidaMovimento(pos))
				jogadasValidas[pos.Linha, pos.Coluna] = true;

			return jogadasValidas;


		}
		public override string ToString()
		{
			return "R";
		}
	}
}
