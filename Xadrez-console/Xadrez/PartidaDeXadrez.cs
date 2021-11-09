using System;
using System.Collections.Generic;
using tabuleiro;

namespace Xadrez
{
	class PartidaDeXadrez
	{
		public Tabuleiro Tabuleiro { get; private set; }
		private int _turno;
		private Cor _jogadorAtual;
		public bool Terminada { get; private set; }
		private List<Peca> _pecasCapturadas = new List<Peca>();

		public PartidaDeXadrez() 
		{
			Tabuleiro = new Tabuleiro(8, 8);
			_turno = 1;
			_jogadorAtual = Cor.Branco;
			Terminada = false;
			IniciarPecas();
		}

		public void ExecutaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino) 
		{
			Peca peca = Tabuleiro.RetirarPeca(posicaoOrigem);
			peca.IncrementaMovimento();
			_pecasCapturadas.Add(Tabuleiro.RetirarPeca(posicaoDestino));
			Tabuleiro.InserePeca(peca, posicaoDestino);
		}

		private void IniciarPecas() 
		{
			Peca torre = new Torre(Tabuleiro, Cor.Preto);
			Tabuleiro.InserePeca(torre, new PosicaoXadrez('c', 1).ConvertePosicao());

			Peca torre1 = new Torre(Tabuleiro, Cor.Preto);
			Tabuleiro.InserePeca(torre1, new PosicaoXadrez('c', 2).ConvertePosicao());

			Peca torre2 = new Torre(Tabuleiro, Cor.Preto);
			Tabuleiro.InserePeca(torre2, new PosicaoXadrez('d', 2).ConvertePosicao());

			Peca torre3 = new Torre(Tabuleiro, Cor.Preto);
			Tabuleiro.InserePeca(torre3, new PosicaoXadrez('e', 2).ConvertePosicao());

			Peca torre4 = new Torre(Tabuleiro, Cor.Preto);
			Tabuleiro.InserePeca(torre4, new PosicaoXadrez('e', 1).ConvertePosicao());

			Peca rei = new Rei(Tabuleiro, Cor.Preto);
			Tabuleiro.InserePeca(rei, new PosicaoXadrez('d', 1).ConvertePosicao());



			Peca torre5 = new Torre(Tabuleiro, Cor.Branco);
			Tabuleiro.InserePeca(torre5, new PosicaoXadrez('c', 8).ConvertePosicao());

			Peca torre6 = new Torre(Tabuleiro, Cor.Branco);
			Tabuleiro.InserePeca(torre6, new PosicaoXadrez('c', 7).ConvertePosicao());

			Peca torre7 = new Torre(Tabuleiro, Cor.Branco);
			Tabuleiro.InserePeca(torre7, new PosicaoXadrez('d', 7).ConvertePosicao());

			Peca torre8 = new Torre(Tabuleiro, Cor.Branco);
			Tabuleiro.InserePeca(torre8, new PosicaoXadrez('e', 7).ConvertePosicao());

			Peca torre9 = new Torre(Tabuleiro, Cor.Branco);
			Tabuleiro.InserePeca(torre9, new PosicaoXadrez('e', 8).ConvertePosicao());

			Peca rei1 = new Rei(Tabuleiro, Cor.Branco);
			Tabuleiro.InserePeca(rei1, new PosicaoXadrez('d', 8).ConvertePosicao());

		}

	}
}
