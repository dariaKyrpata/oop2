public class TreeNode<T> where T : class // Узагальнений вузол дерева, який зберігає об'єкти
{
    public T Value { get; set; } // Значення, яке зберігається у вузлі

    public TreeNode<T>? Left { get; set; } //лівий вузол

    public TreeNode<T>? Right { get; set; } //правий вузол

    public TreeNode(T value) // Конструктор для створення нового вузла
    {
        Value = value; //зберігаємо передане значення
        Left = null; //лівий = null
        Right = null; //правий = null
    }
}