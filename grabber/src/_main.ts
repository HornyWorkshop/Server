import { chromium, Browser } from "playwright";
import { resolve } from "node:path";

async function getProxyList() {
  const browser = await chromium.launch({ devtools: true });
  const page = await browser.newPage();

  try {
    // await page.goto("https://hidemy.name/ru/proxy-list/?country=UA&maxtime=500&type=4#list", { waitUntil: "load" });
    await page.goto("https://hidemy.name/ru/proxy-list/?maxtime=30&type=h#list", { waitUntil: "load" });
    // await page.goto("https://hidemy.name/ru/proxy-list/?maxtime=30&type=h&start=3328#list", { waitUntil: "load" });

    return page.evaluate<string[]>(() => {
      const rows = document.querySelectorAll<HTMLTableRowElement>(".table_block tbody tr");
      return Array.from(rows).map((tr) => `${tr.cells.item(0)?.innerText}:${tr.cells.item(1)?.innerText}`);
    });
  } finally {
    await page.close();
    await browser.close();
  }
}

async function test(browser: Browser, proxy: string) {
  console.log(`test: ${proxy}`);

  const context = await browser.newContext({ proxy: { server: `http://dvprATwqBs8gvrWLM5CCwQ@smartproxy.proxycrawl.com:8012` } });
  const page = await context.newPage();
  const start = performance.now();

  try {
    // await page.goto("https://www.sberbank-ast.ru/UnitedPurchaseList.aspx", { waitUntil: "load" });
    await page.goto("https://google.com");
    console.log("ok");

    // await page.screenshot({ path: resolve("screenshots", `${proxy}.jpeg`), type: "jpeg" });
  } catch (e) {
    // if (e instanceof Error) {
    //   console.log(`[${proxy}] ${e.message}`);
    // } else {
    //   console.log(`[${proxy}] not work`);
    // }
  } finally {
    const end = performance.now();
    console.log(`[${proxy}] ${end - start}ms`);

    await page.close();
  }
}

(async () => {
  const proxies = await getProxyList();

  const browser = await chromium.launch({ proxy: { server: "http://per-context" } });
  await Promise.allSettled(proxies.map(test.bind(undefined, browser)));
  process.exit(0);
})();
