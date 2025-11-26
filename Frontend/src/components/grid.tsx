import React from "react";

type GridDetails = {
  itemId: number;
  itemName: string;
  quantity: number;
  chargeableQuantity: number;
  unitPrice: number;
  lineTotal: number;
  discountAmount: number;
  subTotal: number;
  grandTotal: number;
};

type GridProps = {
  gridData: GridDetails[];
};

const Grid = ({ gridData }: GridProps) => {
  console.log("GRID DATA:", gridData);

  if (gridData.length === 0) return <div>No items in the basket yet.</div>;

  return (
    <div className="mt-4">
      <table className="table table-bordered table-striped">
        <thead>
          <tr>
            <th>S.No</th>
            <th>Item Name</th>
            <th>Quantity</th>
            <th>Rate</th>
            <th>Discount</th>
            <th>Final Amount</th>
          </tr>
        </thead>
        <tbody>
          {gridData.map((item, index) => (
            <tr key={index}>
              <td>{index + 1}</td>
              <td>{item.itemName}</td>
              <td>{item.quantity}</td>
              <td>{item.unitPrice}</td>
              <td>{item.discountAmount}</td>
              <td>{item.grandTotal}</td>
            </tr>
          ))}
          <tr className="h6">
            <td>Total</td>
            <td></td>
            <td>{gridData.reduce((s, i) => s + i.quantity, 0)}</td>
            <td>{gridData.reduce((s, i) => s + i.unitPrice, 0)}</td>
            <td>{gridData.reduce((s, i) => s + i.discountAmount, 0)}</td>
            <td>{gridData.reduce((s, i) => s + i.grandTotal, 0)}</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default Grid;
