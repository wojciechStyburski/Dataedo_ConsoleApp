namespace ConsoleApp.ImportModels
{
    public class ImportedObject : ImportedObjectBaseClass
    {
        public string Schema { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }
        public string DataType { get; set; }
        public bool IsNullable { get; set; }
        public int NumberOfChildren { get; private set; }

        public ImportedObject(string type, string name, string schema, string parentName, string parentType, string dataType, bool isNullable)
        {
            Type = type.ToUpper();
            Name = name;
            Schema = schema;
            ParentName = parentName;
            ParentType = parentType;
            DataType = dataType;
            IsNullable = isNullable;
        }

        public void SetNumberOfChildren()
        {
            NumberOfChildren++;
        }
    }
}
