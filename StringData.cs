using System;
using System.Linq;

public class StringData
{
    public string Value { get; private set; }  // Зберігає текст, змінювати можна лише всередині класу

    public int Length // Повертає довжину рядка
    {
        get { return Value.Length; }
    }

    public StringData(string value) // Конструктор для створення об'єкта з текстом
    {
        Value = value ?? ""; // Якщо value дорівнює null, використовуємо порожній рядок
    }

    public string GetDigits() // Отримує всі цифри з рядка
    {
        return new string(Value.Where(char.IsDigit).ToArray());
    }

    public string GetLetters() // Отримує всі букви з рядка
    {
        return new string(Value.Where(char.IsLetter).ToArray());
    }

    public void Reorder() // Перегруповує символи
    {
        string letters = GetLetters();
        string digits = GetDigits();

        string other = new string(
            Value.Where(c => !char.IsLetterOrDigit(c)).ToArray() // Зберігає інші символи, наприклад ! або ?
        );

        Value = letters + digits + other;
    }

    public override string ToString()
    {
        return $"Value: {Value}, Length: {Length}"; // Повертає текст і його довжину
    }
}