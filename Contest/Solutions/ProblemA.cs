namespace Contest.Solutions
{
	internal class ProblemA
	{
		public static void Execute()
		{
			var quantityOfInputs = int.Parse(Console.ReadLine());

			for (var inputIndex = 0; inputIndex < quantityOfInputs; inputIndex++)
			{
				var quantityOfProducts = int.Parse(Console.ReadLine());
				var productPrices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

				var quantityOfProductsByPrice = new Dictionary<int, int>();
				for (var priceIndex = 0; priceIndex < quantityOfProducts; priceIndex++)
				{
					var price = productPrices[priceIndex];
					if (quantityOfProductsByPrice.ContainsKey(price))
						quantityOfProductsByPrice[price]++;
					else
						quantityOfProductsByPrice.Add(price, 1);
				}

				var promoPrice = 0;

				foreach (var product in quantityOfProductsByPrice)
				{
					promoPrice += ( (product.Value % 3) * product.Key ) + ( 2 * (product.Key * (product.Value / 3)) );
				}

				Console.WriteLine(promoPrice);
			}
		}
	}
}
