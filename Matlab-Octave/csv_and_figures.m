% Opening and Working with CSV Files

% Input variables
input_file_name = "anscombes-quartet.csv";
input_file_directory = "D:/Developer Area/scratch-pad/Datasets/";
delimiter = ",";
skip_header = 1;
column_x = 3;
column_y = 4;

% Strings concatenated using matrix format
file_string = [input_file_directory input_file_name];

% Load dataset
data = dlmread(file_string, delimiter, skip_header, 0);

% Slice out x and y
x = data(:, column_x);
y = data(:, column_y);

% Fit the data
poly = polyfit(x, y, 1);

slope = poly(1);
intercept = poly(2);

% Determine correlation coefficient
r_value = corr(x, y);

% Print results
printf("Slope: %f\n", slope);
printf("Intercept: %f\n", intercept);
printf("Correlation Coefficient: %f/n", r_value);

% Create dataset representing fitted line for plotting
fit_x = linspace(min(x) - 1, max(x) + 1, 100);
fit_y = slope * fit_x + intercept;

% Set figure properties
fig_width = 7;  %inch
fig_height = fig_width / 16 * 9;  %inch
fig_dpi = 100;

% Create figure
fig = figure("units", "inches", "position", [1, 1, fig_width, fig_height]);
ax = axes("parent", fig);

% Define axes parameters
set(ax, "fontsize", 14);
set(ax, "linewidth", 2);

xlim(ax, [min(x) - 1, max(x) + 1]);
ylim(ax, [min(y) - 1, max(y) + 1]);

xlabel(ax, 'x');
ylabel(ax, 'y');