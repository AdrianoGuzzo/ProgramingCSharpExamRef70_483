/// <summary>
/// 1. SRP — Single Responsibility Principle:
///Princípio da Responsabilidade Única — Uma classe deve ter um, e somente um, motivo para mudar.
///Esse princípio declara que uma classe deve ser especializada em um único assunto e possuir apenas uma 
///responsabilidade dentro do software, ou seja, a classe deve ter uma única tarefa ou ação para executar.
/// </summary>
namespace ProgramingCSharpExamRef70_483.SOLID.SRP
{
    /// <summary>
    /// A classe Order viola o SRP porque realiza 3 tipos distintos de tarefas.Além de lidar com as informações do pedido, ela também é responsável pela exibição e manipulação dos dados.
    ///Lembre-se, o princípio da responsabilidade única preza que uma classe deve ter um, e somente um, motivo para mudar.

    ///A violação do Single Responsibility Principle pode gerar alguns problemas, sendo eles:

    ///Falta de coesão — uma classe não deve assumir responsabilidades que não são suas;

    ///Alto acoplamento — Mais responsabilidades geram um maior nível de dependências, deixando o sistema engessado e frágil para alterações;

    ///Dificuldades na implementação de testes automatizados — É difícil de “mockar” esse tipo de classe;

    ///Dificuldades para reaproveitar o código;
    /// </summary>
    public class OrderWrong
    {
        public void CalculateTotalSum() {/*...*/}
        public void GetItems() {/*...*/}
        public void GetItemCount() {/*...*/}
        public void AddItem(object item) {/*...*/}
        public void DeleteItem(object item) {/*...*/}

        public void PrintOrder() {/*...*/}
        public void ShowOrder() {/*...*/}

        public void Load() {/*...*/}
        public void Save() {/*...*/}
        public void Update() {/*...*/}
        public void Delete() {/*...*/}
    }

    /// <summary>
    /// Aplicando o SRP na classe Order, podemos refatorar o código da seguinte forma:
    /// </summary>
    class Order
    {
        public void CalculateTotalSum() {/*...*/}
        public void GetItems() {/*...*/}
        public void GetItemCount() {/*...*/}
        public void AddItem(object item) {/*...*/}
        public void DeleteItem(object item) {/*...*/}
    }

    class OrderRepository
    {
        public void Load(object orderID) {/*...*/}
        public void Save(object order) {/*...*/}
        public void Update(object order) {/*...*/}
        public void Delete(object order) {/*...*/}
    }

    class OrderViewer
    {
        public void PrintOrder(object order) {/*...*/}
        public void ShowOrder(object order) {/*...*/}
    }

    //Perceba no exemplo acima que agora temos 3 classes, cada uma cuidando da sua responsabilidade.

    //O princípio da responsabilidade única não se limita somente a classes, ele também pode ser aplicado em métodos e funções, ou seja,
    //tudo que é responsável por executar uma ação, deve ser responsável por apenas aquilo que se propõe a fazer.

}
