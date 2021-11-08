namespace tabuleiro
{
	class Tabuleiro
	{
		public int Linhas { get; set; }
		public int Colunas { get; set; }

		private Peca[,] _pecas;

		public Tabuleiro() 
		{
		}

		public Tabuleiro(int linhas, int colunas) 
		{
			Linhas = linhas;
			Colunas = colunas;
			_pecas = new Peca[linhas, colunas];
		}

		public Peca GetPeca(int linha, int coluna) 
		{
			return _pecas[linha, coluna];
		}


		public Peca GetPeca(Posicao posicao) 
		{
			return _pecas[posicao.Linha, posicao.Coluna];
		}


		public bool ExistePeca(Posicao posicao) 
		{
			ValidaPosicao(posicao);
			return GetPeca(posicao) != null;

		}

		public bool VerificaPosicao(Posicao posicao)
		{
			if (posicao.Linha < 0 || posicao.Linha > Linhas || posicao.Coluna < 0 || posicao.Coluna > Colunas) 
			{
				return false;			
			}
			return true;
		}

		public void ValidaPosicao(Posicao posicao) 
		{
			if (!VerificaPosicao(posicao)) 
			{
				throw new TabuleiroExceptions("Posicao invalida");
			}
		}

		public void InserePeca(Peca peca, Posicao posicao)
		{
			if (!ExistePeca(posicao)) 
			{
				_pecas[posicao.Linha, posicao.Coluna] = peca;
				peca.Posicao = posicao;
			}
			throw new TabuleiroExceptions("Ja uma existe peça nessa posição!");
		}
	}
}
