using System.Collections.Generic;

public class StringDataComparer : IComparer<StringData>
{
    public int Compare(StringData? x, StringData? y)  // Порівнює два об'єкти
    {
        if (ReferenceEquals(x, y)) // Якщо це один і той самий об'єкт
            return 0;

        if (x == null) // Якщо перший об'єкт відсутній
            return -1;

        if (y == null) // Якщо другий об'єкт відсутній
            return 1;

        int lengthComparison = x.Length.CompareTo(y.Length); // Порівнює довжини рядків

        if (lengthComparison != 0) // Якщо довжини різні, повертаємо результат
            return lengthComparison;

        return string.Compare(
            x.Value,
            y.Value,
            StringComparison.Ordinal
        ); // Якщо довжини однакові, порівнюємо сам текст
    }
}