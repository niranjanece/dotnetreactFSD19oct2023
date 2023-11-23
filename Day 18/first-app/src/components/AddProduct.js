import { useState } from "react";
import "./AddProduct.css"

function AddProduct(){
   // var productName ="Eraser"
    const[name,setName] = useState("");
    const[quantity,setQuantity] = useState(0);
    const[price,setPrice] = useState(0);
    var product;
    var clickAdd =() => {
    //    console.log("Before change"+productName)
        alert('You clicked the button');
        //setProductName("pencil");
    //    productName = "Pencil"
    product ={
        "name" : name,
        "quantity" : quantity,
        "price" : price
    }
        console.log(product)
        fetch('http://localhost:5280/api/Product',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(product)
        }).then(
            ()=>{
                alert("Product Added");
            }
        ).catch((e)=>{
            console.log(e)
        })
    }
    return(
        <div className="inputcontainer">
            <label className="form-control" for="pname">Product</label>
            <input id ="pname" type ="text" className="form-control" value = {name} onChange={(e) => {setName(e.target.value)}}/>
            <label className="form-control" for="Quantity">Quantity</label>
            <input id ="Quantity" type = "number" className="form-control" value={quantity} onChange={(e) => {setQuantity(e.target.value)}}/>
            <label className ="form-control" for ="price">Price</label>
            <input id ="price" className ="form-control" type ="number" value ={price} onChange={(e) => {setPrice(e.target.value)}}/>
            <button onClick={clickAdd} className ="btn btn-primary">Add Product</button>
        </div>
    )
}

export default AddProduct;