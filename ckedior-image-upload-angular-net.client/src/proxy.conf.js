const PROXY_CONFIG = [
  {
    context: [
      "/api",
      "/images"
    ],
    target: "https://localhost:7135",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
