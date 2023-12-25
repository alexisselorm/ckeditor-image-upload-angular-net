const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: "https://localhost:8083",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
