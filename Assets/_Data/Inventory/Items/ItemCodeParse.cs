using System;

public class ItemCodeParse
{
    public static bool TryParse(string input, out ItemEnum itemEnum)
    {
        if (Enum.TryParse(input, out itemEnum))
        {
            if (Enum.IsDefined(typeof(ItemEnum), itemEnum))
            {
                return true;
            }
        }

        itemEnum = default;
        return false;
    }

    public static ItemEnum Parse(string input)
    {
        ItemEnum itemEnum = (ItemEnum)Enum.Parse(typeof(ItemEnum), input);

        if (!Enum.IsDefined(typeof(ItemEnum), itemEnum))
        {
            throw new ArgumentException($"'{input}' is not an enum ItemEnum.");
        }

        return itemEnum;
    }
}