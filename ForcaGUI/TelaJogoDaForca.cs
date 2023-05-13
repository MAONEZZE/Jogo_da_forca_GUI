namespace ForcaGUI
{
    public partial class TelaJogoDaForca : Form
    {
        Forca jogo;
        public TelaJogoDaForca()
        {
            InitializeComponent();
            jogo = new Forca();

            RegistrarEvento(); //Não precisa de um parenteses, pq é um delegate
            ObterPalavraParcial();
            ObterDica();
        }

        public void RegistrarEvento()
        {
            foreach (Button btn in tableLayout.Controls)
            {
                btn.Click += AtribuirLetraPalavra;
                btn.Click += AtualizarBotao;
            }
        }

        private void AtualizarBotao(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
        }

        private void AtribuirLetraPalavra(object? sender, EventArgs e)//sender é a ferramenta que disparou o evento
        {
            Button btn = (Button)sender;

            char palpite = btn.Text[0];

            if (jogo.JogadorAcertou(palpite) || jogo.JogadorPerdeu())
            {
                tableLayout.Enabled = false;
                lbl_mensagemFinal.Text = jogo.mensagemFinal;
            }

            ObterPalavraParcial();
            AtualizarForca();
        }

        private void AtualizarForca()
        {
            switch (jogo.Erros)
            {
                case 0:
                    picbox_imagens.Image = Properties.Resources.forcaVazia;
                    break;
                case 1: 
                    picbox_imagens.Image = Properties.Resources.forcaCabeca;
                    break;
                case 2:
                    picbox_imagens.Image = Properties.Resources.forcaCorpo;
                    break;
                case 3:
                    picbox_imagens.Image = Properties.Resources.forcaB1;
                    break;
                case 4:
                    picbox_imagens.Image = Properties.Resources.forcaB2;
                    break;
                case 5:
                    picbox_imagens.Image = Properties.Resources.forcaP1;
                    break;
                case 6:
                    picbox_imagens.Image = Properties.Resources.forcaP2;
                    break;
            }
        }

        private void ObterPalavraParcial()
        {
            lbl_palavra.Text = jogo.PalavraParcial;
        }

        private void ObterDica()
        {
            lbl_dica.Text = "Fruta com " + jogo.QuantLetra + " Letras";
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            jogo = new Forca();

            ObterPalavraParcial();

            ObterDica();

            AtualizarForca();

            lbl_mensagemFinal.Text = "";

            tableLayout.Enabled = true;

            foreach (Button botao in tableLayout.Controls)
                botao.Enabled = true;
        }
    }
}