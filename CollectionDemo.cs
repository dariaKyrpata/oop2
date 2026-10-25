using System;
using System.Collections;
using System.Collections.Generic;

public static class CollectionDemo
{
    public static void Run() // Запускає порівняння трьох способів зберігання
    {
        StringData[] original =  // Створюємо 4 початкові об'єкти

        {
            new StringData("abc123"),
            new StringData("45hello"),
            new StringData("a1b2c3"),
            new StringData("test789")
        };

        Console.WriteLine("\n=== ARRAY ===");

        StringData[] array = (StringData[])original.Clone(); // Створюємо копію масиву

        Console.WriteLine("Initial array:");
        PrintItems(array); // Виводимо всі елементи

        Array.Resize(ref array, array.Length + 1); // Збільшуємо масив на одне місце
        array[array.Length - 1] = new StringData("new123"); // Додаємо новий елемент

        array[0] = new StringData("updated111"); // Замінюємо перший елемент

        int arrayIndex = Array.FindIndex(
            array,
            item => item.Value == "45hello"  // Шукаємо елемент за його текстом
        );

        Console.WriteLine("Found at index: " + arrayIndex);

        if (arrayIndex >= 0)
        {
            for (int i = arrayIndex; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1]; // Зсуваємо елементи вліво
            }

            Array.Resize(ref array, array.Length - 1); // Зменшуємо розмір масиву
        }

        Console.WriteLine("After changes:");
        PrintItems(array);

        Console.WriteLine("\n=== GENERIC LIST ===");

        List<StringData> list = new List<StringData>(original); // Створюємо узагальнений список

        Console.WriteLine("Initial list:");
        PrintItems(list);

        list.Add(new StringData("new123")); // Додаємо елемент без зміни розміру вручну

        list[0] = new StringData("updated111"); // Оновлюємо перший елемент

        StringData? found = list.Find(
            item => item.Value == "45hello"  // Знаходимо потрібний об'єкт
        );

        Console.WriteLine(
            "Found: " + (found?.Value ?? "Not found") // Показуємо знайдений текст або повідомлення про відсутність
        );

        list.RemoveAll(item => item.Value == "45hello"); // Видаляємо елементи за умовою

        Console.WriteLine("After changes:");
        PrintItems(list);

        Console.WriteLine("\n=== NON-GENERIC ARRAYLIST ===");

        ArrayList arrayList = new ArrayList(original); // Створюємо неузагальнену колекцію

        Console.WriteLine("Initial ArrayList:");
        PrintArrayList(arrayList);

        arrayList.Add(new StringData("new123")); // Додаємо новий об'єкт

        arrayList[0] = new StringData("updated111"); // Замінюємо перший елемент

        int foundIndex = -1; // -1 означає, що елемент ще не знайдено

        for (int i = 0; i < arrayList.Count; i++) // Перебираємо всі елементи
        {
            if (arrayList[i] is StringData item &&
                item.Value == "45hello") // Перевіряємо тип і значення об'єкта
            {
                foundIndex = i; // Запам'ятовуємо позицію
                break; // Зупиняємо пошук
            }
        }

        Console.WriteLine("Found at index: " + foundIndex);

        if (foundIndex >= 0)
        {
            arrayList.RemoveAt(foundIndex); // Видаляємо елемент за індексом
        }

        Console.WriteLine("After changes:");
        PrintArrayList(arrayList);

        Console.WriteLine("\n=== COMPARISON ===");
        Console.WriteLine("Array: fixed size, resizing is manual.");
        Console.WriteLine("List<T>: automatic resizing and type safety.");
        Console.WriteLine("ArrayList: automatic resizing, but stores object.");
    }

    private static void PrintItems(IEnumerable<StringData> items) // Виводить елементи масиву або List
    {
        foreach (StringData item in items) // Перебираємо кожен об'єкт
        {
            Console.WriteLine(item); // Виводимо інформацію через ToString()
        }
    }

    private static void PrintArrayList(ArrayList items) // Виводить елементи ArrayList
    {
        foreach (object? obj in items) // Отримуємо елементи як object
        {
            if (obj is StringData item) // Перевіряємо, чи це об'єкт StringData
            {
                Console.WriteLine(item);
            }
        }
    }
}