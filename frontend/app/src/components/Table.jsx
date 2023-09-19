import "bootstrap/dist/css/bootstrap.min.css";

import Modals from "./Modal.jsx";

function Table(props) {
  const {
    id,
    deleteData,
    modalBtnStyle,
    editData,
    getDataById,
    error,
    data,
    columns,
    rowData,
    handleInputChange,
    labels,
    setError
  } = props;

  return (
    <div className="row ">
      <div className="col-sm-3 mt-1 mb-4 text-gred">
        <div className="search">
          <form className="form-inline">
            <input
              className="form-control mr-sm-2"
              type="search"
              placeholder="Sök"
              aria-label="Search"
            />
          </form>
        </div>
      </div>

      <div className="row">
        <div className="table-responsive">
          <table className="table table-hover table-bordered ">
          <thead  className="table-primary">
              <tr>
                {labels?.map((column, index) => (
                  <th key={index}>{column}</th>
                ))}
                <th>Redigera</th>
              </tr>
            </thead>
            <tbody>
              {data?.map((item, rowIndex) => (
                <tr key={rowIndex}>
                  {columns?.map((column, colIndex) => (
                    <td key={colIndex}>{item[column]}</td>
                  ))}
                  <td className="d-flex justify-content-around">
                    <Modals
                      style={modalBtnStyle}
                      btnName={<i className="material-icons">&#xE254;</i>}
                      title="Redigera"
                      handleInputChange={handleInputChange}
                      getDataById={getDataById}
                      rowData={rowData}
                      columns={columns}
                      labels={labels}
                      editData={editData}
                      error={error}
                      setError={setError}
                      id={item[id]}
                    />
                    <Modals
                      style={modalBtnStyle}
                      btnName={
                        <i className="text-danger material-icons color">
                          &#xE872;
                        </i>
                      }
                      title="Ta bort"
                      handleInputChange={handleInputChange}
                      rowData={rowData}
                      columns={columns}
                      labels={labels}
                      deleteData={deleteData}
                      error={error}
                      id={item[id]}
                    />
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default Table;
