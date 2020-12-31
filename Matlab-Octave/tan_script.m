% Tan script
% Creates plot of tan(x) variables around +/- pi.

% Create lh, center, rh plots
x_part_left = linspace(-pi, -pi/2-0.001, 100);
x_part_center = linspace(-pi/2, pi/2, 100);
x_part_right = linspace(pi/2+0.001, pi, 100);

% Plot variables
plot(x_part_left, tan(x_part_left));
hold on;
plot(x_part_center, tan(x_part_center));
plot(x_part_right, tan(x_part_right));

% Limit axes
y_limit = 4;
axis([-pi, pi, -y_limit, y_limit]);

% Plot asymptotes
plot(linspace(-pi/2, -pi/2, 100), linspace(-y_limit, y_limit, 100), '.');
plot(linspace(pi/2, pi/2, 100), linspace(-y_limit, y_limit, 100), '.');

hold off;