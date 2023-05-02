// For complete examples and data files, please go to https://github.com/aspose-words/Aspose.Words-for-.NET.git.
Document doc = new Document(MyDir + "Tables.docx");

Table firstTable = (Table) doc.GetChild(NodeType.Table, 0, true);

// We will split the table at the third row (inclusive).
Row row = firstTable.Rows[2];

// Create a new container for the split table.
Table table = (Table) firstTable.Clone(false);

// Insert the container after the original.
firstTable.ParentNode.InsertAfter(table, firstTable);

// Add a buffer paragraph to ensure the tables stay apart.
firstTable.ParentNode.InsertAfter(new Paragraph(doc), firstTable);

Row currentRow;

do
{
    currentRow = firstTable.LastRow;
    table.PrependChild(currentRow);
} while (currentRow != row);

doc.Save(ArtifactsDir + "WorkingWithTables.SplitTable.docx");
