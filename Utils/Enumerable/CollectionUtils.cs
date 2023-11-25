// ReSharper disable MemberCanBePrivate.Global

using System.Collections;

namespace Utils.Enumerable;

public static class CollectionUtils
{
    public static IReadOnlyCollection<T> AsReadOnly<T>(this ICollection<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        return source as IReadOnlyCollection<T> ?? new ReadOnlyCollectionAdapter<T>(source);
    }

    private sealed class ReadOnlyCollectionAdapter<T> : IReadOnlyCollection<T>
    {
        private readonly ICollection<T> _source;
        public ReadOnlyCollectionAdapter(ICollection<T> source) => _source = source;
        public int Count => _source.Count;
        public IEnumerator<T> GetEnumerator() => _source.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}