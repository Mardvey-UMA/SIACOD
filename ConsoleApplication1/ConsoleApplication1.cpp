#include <iostream>
#include <vector>
#include <algorithm>
#include <set>
using namespace std;

const int MAX_N = 100;
const int INF = 1e9;
int boardSize;
int distanceMatrix[MAX_N][MAX_N][2];
string board[MAX_N];

bool inBoard(int x, int y) {
    return x >= 0 && y >= 0 && x < boardSize&& y < boardSize;
}

void bfs(int startX, int startY) {
    for (int i = 0; i < boardSize; ++i) {
        for (int j = 0; j < boardSize; ++j) {
            distanceMatrix[i][j][0] = distanceMatrix[i][j][1] = INF;
        }
    }
    distanceMatrix[startX][startY][1] = 0;
    set<pair<pair<int, int>, pair<int, int>>> queue;
    queue.insert({ {0, 1}, {startX, startY} });

    vector<int> dxG = { 0, 0, 1, 1, 1, -1, -1, -1 };
    vector<int> dyG = { 1, -1, 0, 1, -1, 0, 1, -1 };

    vector<int> dxK = { 1, 1, 2, 2, -1, -1, -2, -2 };
    vector<int> dyK = { 2, -2, 1, -1, 2, -2, 1, -1 };


    while (!queue.empty()) {
        int type = queue.begin()->first.second;
        int posX = queue.begin()->second.first;
        int posY = queue.begin()->second.second;
        queue.erase(queue.begin());

        if (type == 0) {
            for (int i = 0; i < dxG.size(); ++i) {
                int newX = posX + dxG[i];
                int newY = posY + dyG[i];
                if (!inBoard(newX, newY)) {
                    continue;
                }
                int newType = 0;
                if (board[newX][newY] == 'K') {
                    newType = 1;
                }
                if (distanceMatrix[newX][newY][newType] > distanceMatrix[posX][posY][type] + 1) {
                    queue.erase({ {distanceMatrix[newX][newY][newType], newType}, {newX, newY} });
                    distanceMatrix[newX][newY][newType] = distanceMatrix[posX][posY][type] + 1;
                    queue.insert({ {distanceMatrix[newX][newY][newType], newType}, {newX, newY} });
                }
            }
        }
        else {
            for (int i = 0; i < dxK.size(); ++i) {
                int newX = posX + dxK[i];
                int newY = posY + dyK[i];

                if (!inBoard(newX, newY)) {
                    continue;
                }
                int newType = 1;
                if (board[newX][newY] == 'G') {
                    newType = 0;
                }

                if (distanceMatrix[newX][newY][newType] > distanceMatrix[posX][posY][type] + 1) {
                    queue.erase({ {distanceMatrix[newX][newY][newType], newType}, {newX, newY} });
                    distanceMatrix[newX][newY][newType] = distanceMatrix[posX][posY][type] + 1;
                    queue.insert({ {distanceMatrix[newX][newY][newType], newType}, {newX, newY} });
                }
            }
        }
    }
}

void solve() {
    cin >> boardSize;
    int startX, startY;
    int endX, endY;
    for (int i = 0; i < boardSize; ++i) {
        cin >> board[i];
        for (int j = 0; j < boardSize; ++j) {
            if (board[i][j] == 'S') {
                startX = i;
                startY = j;
            }
            if (board[i][j] == 'F') {
                endX = i;
                endY = j;
            }
        }
    }

    bfs(startX, startY);
    int minDistance = min(distanceMatrix[endX][endY][0], distanceMatrix[endX][endY][1]);
    if (minDistance == INF) {
        cout << -1 << endl;
    }
    else {
        cout << minDistance << endl;
    }
}

int main() {
    ios::sync_with_stdio(NULL), cin.tie(0), cout.tie(0);
    solve();
    return 0;
}
