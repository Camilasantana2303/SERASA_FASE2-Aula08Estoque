namespace Fase2_Aula08Estoque
{
    public partial class Form1 : Form
    {
        // Variaveis globais
        List<string> produtoNome = new List<string>();
        List<int> produtoQuantidade = new List<int>();

        Utilidades utilidades = new Utilidades();


        public Form1()
        {
            InitializeComponent();
        }

        //Minhas Funções 
        void adicionaProduto()
        {
            if (utilidades.textBoxEstaVazio(txtNome)== true)

            {
                MessageBox.Show("O nome está vazio!");
                return;
            }
            if(utilidades.textBoxEstaVazio(txtQuantidade)== true)
            {
                MessageBox.Show("Quantidade está vazia!");
                return;
            }
            
            string nome = txtNome.Text;
            int quatidade = int.Parse(txtQuantidade.Text);

            produtoNome.Add(nome);
            produtoQuantidade.Add(quatidade);
        }
        void atualizaInterface()
        {
            //Contabiliza a quantidade cadastrada
            int quantidadeCadastrada= produtoNome.Count();
            lblCadastrados.Text = quantidadeCadastrada.ToString();

            // Contabiliza todos os produtos em estoque
            //FOR: a variavel controladora;condição;incrementar o controlador
            int estoque=0;
            for(int i = 0;produtoQuantidade.Count> i;i++)
            {
                int quantidade = produtoQuantidade[i];
                estoque += quantidade;
            }
            lblQuantidade.Text = estoque.ToString();
        }

        void limpaCampos()
        {
            txtNome.Clear();
            txtQuantidade.Text = "";
            txtNome.Focus();
        }

        void verProduto(bool primeiro)
        {
            if(listaEstaVazia() == true)
            {
                MessageBox.Show("Você não pode ver a lista ainda...");
                return;
            }

            string nome;
            int quantidade;

            if (primeiro == true)
            {
               nome= produtoNome[0];
                quantidade = produtoQuantidade[0];
            }
            else
            {
                nome = produtoNome[produtoNome.Count-1];
                quantidade = produtoQuantidade[produtoQuantidade.Count() - 1];
            }

            

            MessageBox.Show($"Nome: {nome}, quantidade: {quantidade}");

        }

        void removerProduto()
        {
            if(listaEstaVazia()==true)
            {
                MessageBox.Show("Você não pode remover");
            }
            else
            {
                produtoNome.RemoveAt(0);
                produtoQuantidade.RemoveAt(0);
                atualizaInterface();
            }

            //produtoNome.RemoveAt(0);
            //  produtoQuantidade.RemoveAt(0);
            //atualizaInterface();


        }

        bool listaEstaVazia()
        {
            if (produtoNome.Count() > 0)
            {
                return false;
            }
            else 
            { 
                return true; 
            }   
        }

        //------------------------------


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            adicionaProduto();
            atualizaInterface();
            limpaCampos();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void btnPrimeiroProduto_Click(object sender, EventArgs e)
        {
            verProduto(true);
        }

        private void btnUltimoProduto_Click(object sender, EventArgs e)
        {
            verProduto(false);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            removerProduto();
        }

        private void b_Click(object sender, EventArgs e)
        {
            Utilidades utilidades = new Utilidades();
            utilidades.mostraMensagem();

            
        }
    }
}