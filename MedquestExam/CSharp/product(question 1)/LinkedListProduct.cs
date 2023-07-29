public class LinkedListProduct
{
    private Product product;
    private LinkedListProduct next;

    public LinkedListProduct(Product product)
    {
        this.product = product;
        this.next = null;
    }

    public Product GetProduct()
    {
        return product;
    }

    public LinkedListProduct GetNext()
    {
        return next;
    }

    public void SetNext(LinkedListProduct next)
    {
        this.next = next;
    }
}
