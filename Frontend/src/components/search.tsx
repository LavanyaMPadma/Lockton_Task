import React, { useEffect, useState } from "react";
import Grid from "./grid";

type GridDetails = {
  itemId: number;
  itemName: string;
  quantity: number; // FIX: API returns number, not string
  chargeableQuantity: number;
  unitPrice: number;
  lineTotal: number;
  discountAmount: number;
  subTotal: number;
  grandTotal: number;
};

type Item = {
  id: number;
  name: string;
};

type ItemsResponse = {
  items: Item[];
};

type GridItemDetails = GridDetails;

type ResponseDetails = {
  item: GridItemDetails[];
};

const Search = () => {
  const [formData, setFormData] = useState({
    itemName: "",
    quantity: "",
  });

  const [items, setItems] = useState<Item[]>([]);
  const [gridData, setGridData] = useState<GridItemDetails[]>([]);

  const getItems = async () => {
    try {
      const response = await fetch("https://localhost:7188/api/items");
      if (response.ok) {
        const d: ItemsResponse = await response.json();
        setItems(d.items);
      }
    } catch (err) {
      console.error(err);
    }
  };

  useEffect(() => {
    getItems();
  }, []);

  const changeHandler = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    getPriceDetails();
  };

  const getPriceDetails = async () => {
    const requestBody = {
      items: [
        {
          itemId: Number(formData.itemName),
          quantity: Number(formData.quantity),
        },
      ],
    };

    try {
      const response = await fetch(
        "https://localhost:7188/api/pricing/calculate",
        {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(requestBody),
        }
      );

      if (response.ok) {
        const a: ResponseDetails = await response.json();
        setGridData((prev) => [...prev, ...a.item]);

        setFormData({ itemName: "", quantity: "" });
      }
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <div className="container mt-4">
      <form className="row g-3 align-items-end" onSubmit={handleSubmit}>
        <div className="col-md-4">
          <label className="form-label">Quantity</label>
          <input
            type="number"
            className="form-control"
            name="quantity"
            value={formData.quantity}
            onChange={changeHandler}
            required
          />
        </div>

        <div className="col-md-4">
          <label className="form-label">Select Item</label>
          <select
            className="form-select"
            name="itemName"
            value={formData.itemName}
            onChange={changeHandler}
            required
          >
            <option value="">Select</option>

            {items.map((item) => (
              <option key={item.id} value={item.id}>
                {item.name}
              </option>
            ))}
          </select>
        </div>

        <div className="col-md-4">
          <button type="submit" className="btn btn-primary w-100">
            Submit
          </button>
        </div>
      </form>

      <Grid gridData={gridData} />
    </div>
  );
};

export default Search;
