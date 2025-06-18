from abc import ABC, abstractmethod

class Document(ABC):
    @abstractmethod
    def print(self):
        pass

    def prepare_for_printing(self):
        print("Preparing document for printing...")
        self.print()


class PDFDocument(Document):
    def print(self):
        print("Printing PDF document...")


class WordDocument(Document):
    def print(self):
        print("Printing Word document...")


class ExcelDocument(Document):
    def print(self):
        print("Printing Excel document...")


class DocumentFactory:
    @staticmethod
    def create_document(doc_type: str) -> Document:
        if doc_type == 'pdf':
            return PDFDocument()
        elif doc_type == 'word':
            return WordDocument()
        elif doc_type == 'excel':
            return ExcelDocument()
        else:
            raise ValueError(f"Unknown document type: {doc_type}")


if __name__ == "__main__":
    types = ['pdf', 'word', 'excel']
    for t in types:
        doc = DocumentFactory.create_document(t)
        doc.prepare_for_printing()
