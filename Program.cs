using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        
        // Cria uma nova reserva, passando a suíte e os hóspedes
        Reserva reserva = new Reserva();
        List<Pessoa> hospedes = new List<Pessoa>();
        
        Console.WriteLine("Bem vindo(a) ao Hotel MiraMar, vamos dar inicio a sua reserva.");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Escolha sua suíte.");
        Console.WriteLine("--------------------------------------------------------------");
        reserva.Suite = reserva.CadastrarSuite();

        bool cadastro = true;

        while(cadastro){
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Sobrenome: ");
            string sobrenome = Console.ReadLine();

            hospedes.Add(new Pessoa(nome,sobrenome));

            Console.WriteLine("Deseja adicionar mais um hóspede? s/n");
            string resposta = Console.ReadLine().ToLower();
            if(resposta != "s"){
                cadastro = false;
            }
        }

        try{
            reserva.CadastrarHospedes(hospedes);
            Console.WriteLine("Hóspede(s) cadastrado com sucesso.");

            foreach (var hospede in reserva.Hospedes)
                {
                    Console.WriteLine(hospede.NomeCompleto);
                }
            decimal valorDiaria = reserva.CalcularValorDiaria();
            Console.WriteLine($"Valor total da diária para {reserva.DiasReservados} dias: R$ {valorDiaria}");
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        
    }
}