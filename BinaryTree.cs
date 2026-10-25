using System;
using System.Collections;
using System.Collections.Generic;

public class BinaryTree<T> : IEnumerable<T> where T : class
{
    private TreeNode<T>? root; // Головний вузол дерева
    private readonly IComparer<T> comparer; // Визначає правила порівняння елементів

    public BinaryTree(IComparer<T> comparer) // Конструктор приймає компаратор
    {
        this.comparer = comparer;
    }

    public void Add(T value) // Додає новий елемент у дерево
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value)); // Забороняємо додавати null

        root = AddNode(root, value);
    }

    private TreeNode<T> AddNode(TreeNode<T>? node, T value) // Шукає місце для нового вузла
    {
        if (node == null)
            return new TreeNode<T>(value); // Якщо місце порожнє, створюємо вузол

        int comparison = comparer.Compare(value, node.Value); // Порівнюємо нове значення з поточним

        if (comparison < 0)
        {
            node.Left = AddNode(node.Left, value); // Менше значення додаємо ліворуч
        }
        else
        {
            node.Right = AddNode(node.Right, value); // Більше або рівне — праворуч
        }

        return node;
    }

    public bool Contains(T value) // Перевіряє, чи є елемент у дереві
    {
        TreeNode<T>? current = root; // Починаємо пошук із кореня

        while (current != null)
        {
            int comparison = comparer.Compare(value, current.Value);

            if (comparison == 0)
                return true; // Елемент знайдено

            if (comparison < 0)
                current = current.Left; // Шукаємо в лівій частині
            else
                current = current.Right; // Шукаємо в правій частині
        }

        return false; // Елемент не знайдено
    }

    public IEnumerator<T> GetEnumerator() // Дозволяє перебирати дерево через foreach
    {
        return PostOrder(root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() // Підтримка звичайного IEnumerable
    {
        return GetEnumerator();
    }

    private IEnumerable<T> PostOrder(TreeNode<T>? node) // Зворотний обхід дерева
    {
        if (node == null)
            yield break; // Завершує обхід, якщо вузла немає

        foreach (T value in PostOrder(node.Left))
            yield return value; // Спочатку обходимо ліве піддерево

        foreach (T value in PostOrder(node.Right))
            yield return value; // Потім обходимо праве піддерево

        yield return node.Value;
    }
}