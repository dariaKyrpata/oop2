using System;
using System.Collections.Generic;

Console.WriteLine("=== OOP LAB 3.2 / VARIANT 14 ===");

StringData[] items = // Створюємо масив із 4 об'єктів

{
    new StringData("abc123"),
    new StringData("45hello"),
    new StringData("a1b2c3"),
    new StringData("test789")
};

Console.WriteLine("\n=== STRING OPERATIONS ===");

foreach (StringData item in items) // Перебираємо всі об'єкти масиву
{
    Console.WriteLine("\n" + item); // Виводимо об'єкт через ToString()
    Console.WriteLine("Digits: " + item.GetDigits()); // Отримуємо цифри
    Console.WriteLine("Letters: " + item.GetLetters()); // Отримуємо букви

    item.Reorder(); // Перегруповуємо символи рядка

    Console.WriteLine("Reordered: " + item.Value); // Показуємо результат
}

Console.WriteLine("\n=== COLLECTION OPERATIONS ===");

CollectionDemo.Run(); // Запускаємо демонстрацію роботи з колекціями

StringDataComparer comparer = new StringDataComparer(); // Створюємо об'єкт для порівняння рядків

Console.WriteLine("\n=== SORTING ===");

List<StringData> sortedItems = new List<StringData>(items); // Створюємо список із масиву

sortedItems.Sort(comparer); // Сортуємо за правилами нашого компаратора

foreach (StringData item in sortedItems) // Сортуємо за правилами нашого компаратора
{
    Console.WriteLine(item);
}

Console.WriteLine("\n=== BINARY TREE ===");

BinaryTree<StringData> tree = new BinaryTree<StringData>(comparer); // Створюємо бінарне дерево

foreach (StringData item in items)
{
    tree.Add(item); // Створюємо бінарне дерево
}

StringData searchItem = items[1]; // Вибираємо другий об'єкт для пошуку

Console.WriteLine(
    "Search for " + searchItem.Value + ": " + tree.Contains(searchItem) // Перевіряємо, чи є елемент у дереві
);

Console.WriteLine("\nPostorder traversal:");

foreach (StringData item in tree) // Обходимо дерево в порядку postorder
{
    Console.WriteLine(item); // Виводимо поточний елемент
}

Console.WriteLine("\nProgram completed successfully.");

Console.ReadKey(); 