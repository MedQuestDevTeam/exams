public class ShoppingCart
{
    private LinkedListProduct head;
    private LinkedListProduct tail;

    public void AddProduct(Product product)
    {
        //Function To add product into shopping cart
        LinkedListProduct newProduct = new LinkedListProduct(product);

        //check if the list is empty, put at the first if yes, otherwise append it
        if (head == null)
        {
            head = newProduct;
            tail = newProduct;
        }
        else
        {
            tail.SetNext(newProduct);
            tail = newProduct;
        }
    }

    public void RemoveProduct(Product product)
    {
        //Function To remove Product from shopping cart
        LinkedListProduct current = head;
        LinkedListProduct previous = null;

        while (current != null)
        {
            //check if the current element is mathc what we finding
            if (current.GetProduct() == product)
            {
                if (previous == null)
                {
                    head = current.GetNext();
                }
                else
                {
                    previous.SetNext(current.GetNext());
                }

                //escape the loop if element found
                break;
            }

            //point to the next element
            previous = current;
            current = current.GetNext();
        }
    }

    public decimal GetTotal()
    {
        decimal total = 0;
        LinkedListProduct current = head;

        while (current != null)
        {
            total += current.GetProduct().Price;
            current = current.GetNext();
        }

        return total;
    }
}
