namespace ProductProcessing
{
    public interface IMultipartParameter
    {
        String ParamName { get; }
        byte[] Value { get; }
        String FileName { get; }
        String ContentType { get; }
    }
}
