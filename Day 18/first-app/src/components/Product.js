import './Product.css';

function Product(){
    //var productName = "Pencil";
    var product = {
        name : "Pencil",
        price : 10,
        quantity : 6
    }
    var checkQuantity = product.quantity>0?true:false;
    return(
        <div class = 'product'>
            {checkQuantity?
            <div>
            Product Name = {product.name}
            <br/>
            Product Price = {product.price}
            <br/>
            Product Quantity = {product.quantity}
            </div>
            :
            <div>No product available </div>
            }
        </div>
    )
}

export default Product;