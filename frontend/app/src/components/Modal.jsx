import React from "react";
import { useState } from "react";
import { Button, Modal } from "react-bootstrap";

const Modals = (props) => {
  const {
    style,
    id,
    getDataById,
    deleteData,
    editData,
    btnName,
    error,
    title,
    labels,
    columns,
    rowData,
    handleInputChange,
    sendData,
    setError,
    setRowData,
  } = props;
  const [show, setShow] = useState(false);
  const [currentData, setCurrentData] = useState({});
 
  const handleClose = () => {
    setError("")
  
      for (let i = 0; i < columns.length; i++) {
        if(sendData){
        setRowData({
          ...rowData,
          [columns[i]]: "",
        })
        
      }
    else if(editData){
      setCurrentData({
        ...rowData,
        [columns[i]]: "",
      })
    }}
     
   
    setShow(false);
  }
  const handleSendData = async (e) => {
    e.preventDefault();
    const res = await sendData();
    console.log(res);
    if (res === "") {
      handleClose();
    }

    return;
  };

  const handleEditData = async (e) => {
    e.preventDefault();
    console.log(currentData)
    const res = await editData(id, currentData);
    console.log(res);
    if (res === "") {
      handleClose();
    }
  };

  const handleDeleteData = async () => {
    const res = await deleteData(id);
    console.log(res);
    handleClose();
  };

  const handleShow = async () => {
    setShow(true);
    if (editData) {
      setCurrentData(await getDataById(id));
    }
  };
  return (
    <div>
      <button className={style} onClick={handleShow}>
        {btnName}
      </button>

      <div className="model_box">
        <Modal
          show={show}
          onHide={handleClose}
          backdrop="static"
          keyboard={false}
        >
          <Modal.Header closeButton>
            <Modal.Title>{title}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            {!deleteData ? (
              <form>
                {labels?.map((placeholder, index) => (
                  <div key={index} className="form-group">
                    <input
                    required
                      className="form-control"
                      id={placeholder}
                      placeholder={
                        editData && !sendData ? currentData[columns[index]] : placeholder
                      }
                      value={rowData?.[columns[index]] || "" }
                      onChange={(e) =>{
                        setCurrentData({...currentData, [columns[index]]: e.target.value})
                        handleInputChange(columns[index], e.target.value)
                      }}
                      
                    />
                  </div>
                ))}
                <div style={{ color: "red" }}>{error}</div>
                {sendData ? (
                  <button
                    type="submit"
                    onClick={handleSendData}
                    className="btn btn-success mt-4"
                  >
                    Lägg till
                  </button>
                ) : (
                  <button
                    onClick={handleEditData}
                    className="btn btn-success mt-4"
                  >
                    Ändra
                  </button>
                )}
              </form>
            ) : (
              <div>
                <p>Är du säker att du vill ta bort raden med id: {id} ?</p>
                <button
                  type="submit"
                  onClick={handleDeleteData}
                  className="btn btn-danger mt-4"
                >
                  Ta bort
                </button>
              </div>
            )}
          </Modal.Body>

          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Avbryt
            </Button>
          </Modal.Footer>
        </Modal>
      </div>
    </div>
  );
};

export default Modals;
