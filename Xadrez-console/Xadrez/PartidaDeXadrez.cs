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
			_pecasCapturadas.Add(Tabuleiro.RetirarPeca(posicaoDestino));
			Tabuleiro.InserePeca(peca, posicaoDestino);
		}

		private void IniciarPecas() 
		{
			Tabuleiro = new Tabuleiro(8, 8);
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 1).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 2).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 2).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 2).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 1).ConvertePosicao());
			Tabuleiro.InserePeca(new Rei(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 1).ConvertePosicao());

			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 7).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 8).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 7).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 7).ConvertePosicao());
			Tabuleiro.InserePeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 8).ConvertePosicao());
			Tabuleiro.InserePeca(new Rei(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 8).ConvertePosicao());
		}

	}
}
