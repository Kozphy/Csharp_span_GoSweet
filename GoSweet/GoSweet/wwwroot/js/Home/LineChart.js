// get yahoo Finance  data
async function fetchYahooFinanceData() {
    /*
        {
          "Code": "string",
          "Name": "string",
          "ClosingPrice": "string",
          "MonthlyAveragePrice": "string"
        }
    */
    const twseData =
    `https://openapi.twse.com.tw/v1/exchangeReport/STOCK_DAY_AVG_ALL`

    try {
        const response = await fetch(twseData);
        const data = await response.json();
        console.log(data); // Handle the data as needed
        let endData =
        {
            ClosingPrice: data.ClosingPrice,
            MonthlyAveragePrice: MonthlyAveragePrice,
        }
        return endData;
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

let data =  fetchYahooFinanceData(symbol);

let lineChartContainer = document.querySelector("#line-chart-container");
// Declare the chart dimensions and margins.
const width = 928;
const height = 500;
const marginTop = 20;
const marginRight = 30;
const marginBottom = 30;
const marginLeft = 40;

// Create the candlestick elements
var svg2 = d3.select("#line-chart-container")
    .append("svg2")
    .attr("width", width)
    .attr("height", height);

// Declare the x (horizontal position) scale.
const x = d3.scaleUtc(
    d3.extent(data, d => d.date),
    [marginLeft, width - marginRight]);

// Declare the y (vertical position) scale.
const y = d3.scaleLinear(
    [0, d3.max(data, d => d.close)],
    [height - marginBottom, marginTop]);

// Declare the line generator.
const line = d3.line()
    .x(d => x(d.date))
    .y(d => y(d.close));

// Create the SVG container.
const svg2 = d3.create("svg2")
    .attr("width", width)
    .attr("height", height)
    .attr("viewBox", [0, 0, width, height])
    .attr("style", "max-width: 100%; height: auto; height: intrinsic;");

// Add the x-axis.
svg2.append("g")
    .attr("transform", `translate(0,${height - marginBottom})`)
    .call(d3.axisBottom(x).ticks(width / 80).tickSizeOuter(0));

// Add the y-axis, remove the domain line, 
// add grid lines and a label.
svg2.append("g")
    .attr("transform", `translate(${marginLeft},0)`)
    .call(d3.axisLeft(y).ticks(height / 40))
    .call(g => g.select(".domain").remove())
    .call(g => g.selectAll(".tick line").clone()
        .attr("x2", width - marginLeft - marginRight)
        .attr("stroke-opacity", 0.1))
    .call(g => g.append("text")
        .attr("x", -marginLeft)
        .attr("y", 10)
        .attr("fill", "currentColor")
        .attr("text-anchor", "start")
        .text("↑ Daily close ($)"));

// Append a path for the line.
svg2.append("path")
    .attr("fill", "none")
    .attr("stroke", "steelblue")
    .attr("stroke-width", 1.5)
    .attr("d", line(data));

lineChartContainer.append(svg2.node());