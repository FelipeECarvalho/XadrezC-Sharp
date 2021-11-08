namespace tabuleiro
{
	class PosicaoXadrez
	{
		public char Coluna { get; set; }
		public int Linha { get; set; }

		public PosicaoXadrez(char coluna, int linha) 
		{
			Linha = linha;
			Coluna = coluna;
		}

		public Posicao ConvertePosicao() 
		{
			return new Posicao(8 - Linha, Coluna - 'a');
		}

		public override string ToString()
		{
			return "" + Coluna + Linha;
		}
	}
}
