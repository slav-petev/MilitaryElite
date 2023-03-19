namespace MilitaryElite.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Pair<T>(this IEnumerable<T> source)
        {
            return source
                .Where((x, i) => i % 2 == 0)
                .Select((x, i) => source.Skip(i * 2).Take(2));
        }
        
        public static string FormatForPrint<T>(this IEnumerable<T> elements, string title)
        {
            var separator = elements.Any() ? Environment.NewLine : string.Empty;
            var elementsAsStrings = elements
                .Where(element => !string.IsNullOrWhiteSpace(element?.ToString()))
                .Select(element => $"\t{element}");
            
            return $"{title}:{separator}{string.Join(Environment.NewLine, elementsAsStrings)}";
        }
    }
}
