import React from "react";
import Table from "../Table";
import { httpDelete, httpGet, httpPatch, httpPost } from "../api/apiCRUD";
import {
  productJsonColumns,
  produktColumns,
  tableTitle,
} from "../data/textData";
import { useState } from "react";
import { useEffect } from "react";
import {
  compareObjectProperties,
  compareObjectPropertiesAfterEdit,
 // compareObjectPropertiesContainsMoreThanOne,
  updateObjectInArray,
} from "../data/helperFunctions";
import Modals from "../Modal";
import "./Pages.css";

const URL = "http://localhost:5230/api/Produkter";

const Produkter = () => {
  const [data, setData] = useState();
  const [error, setError] = useState("");
  //för att skicka data till backend så använder jag nedan state
  const [rowData, setRowData] = useState({});

  const handleInputChange = (placeholder, value) => {
    setRowData({
      ...rowData,
      [placeholder]: value,
    });
  };

  useEffect(() => {
    async function fetchData() {
      try {
        const res = await httpGet(URL);
        setData(res);
      } catch (error) {
        console.error("Error:", error);
      }
    }
    fetchData();
  }, []);

  async function sendData() {
    const result = compareObjectProperties(rowData, data, ["pris"]);
    if (result.hasMatch) {
      setError(result.matchingPropertyMessage);
      return result.matchingPropertyMessage;
    } else {
      setError("");
    }
    try {
      const res = await httpPost(URL, rowData);
      // If the data is successfully sent, update the data state
      const updatedData = [...data, rowData];
      updatedData.sort((a, b) => {
        // Use localeCompare to compare string values
        return a.produktnr.localeCompare(b.produktnr);
      });
      setData(updatedData);
      setRowData({});
      return "";
    } catch (error) {
      console.error("Error:", error);
      setError(error);
      return "error";
    }
  }

  async function getDataById(id) {
    try {
      const response = await httpGet(`${URL}/${id}`);
      return response;
    } catch (error) {
      console.error(error);
      setError(error);
    }
  }

  async function editData(id, editedData) {
   
    const result = compareObjectPropertiesAfterEdit(editedData, data, ["pris"]);
    if (result.hasMatch) {
      setError(result.matchingPropertyMessage);
      return result.matchingPropertyMessage;
    } else {
      setError("");
    }
    try {
      console.log("in EditData", editedData)
      const res = await httpPatch(`${URL}/${id}`, editedData);
      console.log(res)

      const updatedData = updateObjectInArray(data, "produktnr", res);
      setData(updatedData);
      console.log(res);
      return "";
    } catch (error) {
      console.error("Error:", error);
      setError(error);
      return "error";
    }
  }

  async function deleteData(id) {
    console.log(rowData);
    const res = await httpDelete(`${URL}/${id}`);
    setData(()=>data.filter((row)=>row.produktnr !== res.produktnr))
    
  }

  return (
    <div className="container">
      <div className="crud shadow-lg p-3 mb-5 mt-5 bg-body rounded">
        <div className="col-sm-3 offset-sm-5 mt-5 mb-4">
          <div>
            <h1 style={{ color: "#023b6d" }}>
              <b>{tableTitle[0]}</b>
            </h1>
          </div>
        </div>
        <div className="d-flex flex-row-reverse ">
          <Modals
            style="p-2 border-0 bg-primary text-white rounded shadow-sm mr-4"
            btnName="Lägg till Produkt"
            title={"Lägg till Produkt"}
            handleInputChange={handleInputChange}
            rowData={rowData}
            setRowData={setRowData}
            columns={productJsonColumns}
            labels={produktColumns}
            sendData={sendData}
            error={error}
            setError={setError}
          />
        </div>
        <Table
          modalBtnStyle="border-0 bg-transparent"
          id="produktnr"
          getDataById={getDataById}
          handleInputChange={handleInputChange}
          data={data}
          columns={productJsonColumns}
          labels={produktColumns}
          error={error}
          setError={setError}
          editData={editData}
          deleteData={deleteData}
        />
      </div>
    </div>
  );
};

export default Produkter;
