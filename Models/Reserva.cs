using System.Data;
using System.Runtime.InteropServices;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { 
            
        }

        public Reserva(int diasReservados)
        {
            Hospedes = new List<Pessoa>();
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new Exception("A capacidade da suíte é menor que o número de hóspedes. Escolha outra suíte.");
            }
            
        }

        public Suite CadastrarSuite()
        {
            Suite [] suites = new Suite[]{
                new Suite("Premium",4, 300),
                new Suite("Normal", 4, 200),
                new Suite("Solteiro", 1, 100),
                new Suite("Casal", 2, 200),
                new Suite("Casal Premium", 2, 400)
            };
            Console.WriteLine("Opções de suítes: ");
            for(int i = 0; i < suites.Length; i++){
                Console.WriteLine($"{i + 1} - {suites[i].TipoSuite} com capacidade para {suites[i].Capacidade} pessoa(s) - R$ {suites[i].ValorDiaria} ");
            }
            int escolhaUsuario;
            do{
                Console.Write("Digite o número da suite escolhida: ");
                escolhaUsuario = int.Parse(Console.ReadLine());
                } while (escolhaUsuario < 1 || escolhaUsuario > suites.Length);
            return suites[escolhaUsuario - 1];

        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Dias reservados: ");
            DiasReservados = int.Parse(Console.ReadLine());
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor = valor - (valor * 0.10M);
            }

            return valor;
        }
    }
}