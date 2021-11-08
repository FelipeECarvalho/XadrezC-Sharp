using System;

namespace tabuleiro
{
	class TabuleiroExceptions: ApplicationException
	{
		public TabuleiroExceptions(string mensagem) : base(mensagem) 
		{
		}
	}
}
