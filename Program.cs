namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRecords = 10;

            Product product1 = new Product("Bread", 30.1, 5);
            Product product2 = new Product("Apples", 15, 0);
            Product product3 = new Product("Milk", 20.15, 15);

            ShoppingList shoppingList = new ShoppingList(product1);

            //Добавление в лист
            shoppingList.AddProduct(product2);
            shoppingList.AddProduct(product3);
            Console.WriteLine(shoppingList);

            //Удаление элемента из листа при помощи двух способов
            shoppingList.RemoveProduct(product1);
            Console.WriteLine(shoppingList);
            shoppingList.RemoveProduct(1);
            Console.WriteLine(shoppingList);

            //Создание случайных продуктов и добавление их в лист
            DataStore ds = new DataStore();
            shoppingList.AddProduct(ds.CreateProductRecord());
            shoppingList.AddProduct(ds.CreateProductRecord());
            Console.WriteLine(shoppingList);

            //Создаем N-ое количество записей случайным образом
            for (int i = 0; i < numberOfRecords; i++)
            {
                shoppingList.AddProduct(ds.CreateProductRecord());
            }

            
            string fileNameBin = "ShopingList.bin";
            string fileNameJson = "ShopingList.json";

            //Сериализация
            FileManager.SavingToBinary(shoppingList, fileNameBin);
            FileManager.SerializationToJSON(shoppingList, fileNameJson);

            //Console.WriteLine(FileManager.LoadingFromBinary(fileNameBin));

            //Десериализация
            ShoppingList productsBin = (ShoppingList)FileManager.LoadingFromBinary(fileNameBin);
            ShoppingList productsJson = (ShoppingList)FileManager.DeserializationFromJSON(fileNameJson, shoppingList);

            
            Console.WriteLine($"File: {fileNameBin} \n {productsBin}");
            Console.WriteLine($"File: {fileNameJson} \n {productsJson}");

            Console.WriteLine("------------------------");
            
        }
    }
}