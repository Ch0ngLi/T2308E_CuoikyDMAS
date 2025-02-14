import React, { useEffect, useState } from 'react';

const ReportTable = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5000/api/report/getassetsbyplayer") // Thay localhost:5000 bằng URL thực tế của API
            .then(response => response.json())
            .then(data => setData(data))
            .catch(error => console.error("Error fetching data:", error));
    }, []);

    return (
        <div>
            <h2>Player Assets Report</h2>
            <table border="1" width="100%" cellPadding="10">
                <thead>
                <tr>
                    <th>No</th>
                    <th>Player Name</th>
                    <th>Level</th>
                    <th>Age</th>
                    <th>Asset Name</th>
                </tr>
                </thead>
                <tbody>
                {data.length > 0 ? (
                    data.map((item, index) => (
                        <tr key={index}>
                            <td>{index + 1}</td>
                            <td>{item.playerName}</td>
                            <td>{item.level}</td>
                            <td>{item.age}</td>
                            <td>{item.assetName}</td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan="5">Loading...</td>
                    </tr>
                )}
                </tbody>
            </table>
        </div>
    );
};

export default ReportTable;
