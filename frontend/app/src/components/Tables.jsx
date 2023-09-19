import React, { useEffect, useState } from "react";
import Table from "./Table";
import "./Tables.css";
import { tableTitle } from "./data/textData";
import Produkter from "./pages/Produkter";

const Tables = () => {

  
  const placeholders = ["Placeholder1", "Placeholder2", "Placeholder3"];
  const mockData = [
    {
      "Contest Name": "Contest 1",
      Date: "2023-09-15",
      "Award Position": "1st Place",
    },
    {
      "Contest Name": "Contest 2",
      Date: "2023-09-20",
      "Award Position": "2nd Place",
    },
    {
      "Contest Name": "Contest 3",
      Date: "2023-09-25",
      "Award Position": "3rd Place",
    },
    {
      "Contest Name": "Contest 4",
      Date: "2023-09-30",
      "Award Position": "Participant",
    },
  ];

  const mockData2 = [
    {
      Product: "Widget A",
      Price: 10.99,
      Stock: 100,
    },
    {
      Product: "Widget B",
      Price: 19.99,
      Stock: 50,
    },
    {
      Product: "Widget C",
      Price: 8.49,
      Stock: 75,
    },
    {
      Product: "Widget D",
      Price: 15.75,
      Stock: 30,
    },
  ];

  const mockData3 = [
    {
      "Student Name": "Alice Johnson",
      Age: 22,
      Grade: "A",
    },
    {
      "Student Name": "Bob Smith",
      Age: 20,
      Grade: "B",
    },
    {
      "Student Name": "Charlie Brown",
      Age: 21,
      Grade: "B+",
    },
    {
      "Student Name": "David Lee",
      Age: 23,
      Grade: "A-",
    },
  ];

  const mockDataNew = [
    {
      id: 1,
      name: "Mana Octo",
      address: "Deban Street",
      city: "New York",
      country: "USA",
    },
    {
      id: 2,
      name: "Haris",
      address: "City Road.13",
      city: "Dubai",
      country: "UAE",
    },
    {
      id: 3,
      name: "Semir Deba",
      address: "Ocol Str. 57",
      city: "Berlin",
      country: "Germany",
    },
    {
      id: 4,
      name: "James Cott",
      address: "Berut Road",
      city: "Paris",
      country: "France",
    },
    {
      id: 5,
      name: "Dheraj",
      address: "Bulf Str. 57",
      city: "Delhi",
      country: "India",
    },
    {
      id: 6,
      name: "Maria James",
      address: "Obere Str. 57",
      city: "Tokyo",
      country: "Japan",
    },
  ];

  return (
    <div>
      <section id="tabs" className="project-tab">
        <div className="container">
          <div className="row">
            <div className="col-md-12">
              <nav>
                <div className="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                  <a
                    className="nav-item nav-link active"
                    id="nav-home-tab"
                    data-toggle="tab"
                    href="#nav-home"
                    role="tab"
                    aria-controls="nav-home"
                    aria-selected="true"
                  >
                    {tableTitle[0]}
                  </a>
                  <a
                    className="nav-item nav-link"
                    id="nav-profile-tab"
                    data-toggle="tab"
                    href="#nav-profile"
                    role="tab"
                    aria-controls="nav-profile"
                    aria-selected="false"
                  >
                   {tableTitle[1]}
                  </a>
                  <a
                    className="nav-item nav-link"
                    id="nav-contact-tab"
                    data-toggle="tab"
                    href="#nav-contact"
                    role="tab"
                    aria-controls="nav-contact"
                    aria-selected="false"
                  >
                   {tableTitle[2]}
                  </a>
                  <a
                    className="nav-item nav-link"
                    id="nav-noob-tab"
                    data-toggle="tab"
                    href="#nav-noob"
                    role="tab"
                    aria-controls="nav-noob"
                    aria-selected="false"
                  >
                    {tableTitle[3]}
                  </a>
                </div>
              </nav>
              <div className="tab-content" id="nav-tabContent">
                <div
                  className="tab-pane fade show active"
                  id="nav-home"
                  role="tabpanel"
                  aria-labelledby="nav-home-tab"
                >
                  <Produkter />
                 
                </div>
                <div
                  className="tab-pane fade"
                  id="nav-profile"
                  role="tabpanel"
                  aria-labelledby="nav-profile-tab"
                >
                   <Table title={tableTitle[0]} data={mockData} />
                </div>
                <div
                  className="tab-pane fade"
                  id="nav-contact"
                  role="tabpanel"
                  aria-labelledby="nav-contact-tab"
                >
                  <Table title={tableTitle[2]} data={mockData3} />
                </div>
                <div
                  className="tab-pane fade"
                  id="nav-noob"
                  role="tabpanel"
                  aria-labelledby="nav-noob-tab"
                >
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Tables;
