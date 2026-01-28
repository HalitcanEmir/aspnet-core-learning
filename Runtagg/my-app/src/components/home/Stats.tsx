import SectionWrapper from "./SectionWrapper";

const stats = [
  {
    label: "Active crew members",
    value: "10+",
  },
  {
    label: "Shipped projects",
    value: "5+",
  },
  {
    label: "Hackathon / competition finals",
    value: "3",
  },
  {
    label: "Hours of playtesting",
    value: "100+",
  },
];

export default function Stats() {
  return (
    <SectionWrapper id="stats" className="space-y-8">
      <div className="space-y-3">
        <p className="text-[11px] font-semibold uppercase tracking-[0.3em] text-slate-400">
          Impact
        </p>
        <h2 className="text-2xl font-semibold uppercase tracking-[0.18em] text-slate-100 sm:text-3xl">
          Numbers that actually matter
        </h2>
        <p className="max-w-xl text-sm text-slate-300">
          Not inflated metrics — just simple signals that our crews are active,
          shipping and learning.
        </p>
      </div>

      <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4">
        {stats.map((stat) => (
          <div
            key={stat.label}
            className="glass-panel-subtle flex flex-col gap-1 rounded-2xl border border-white/12 bg-slate-950/70 px-5 py-4"
          >
            <span className="text-2xl font-semibold text-slate-50">
              {stat.value}
            </span>
            <span className="text-[11px] uppercase tracking-[0.24em] text-slate-400">
              {stat.label}
            </span>
          </div>
        ))}
      </div>
    </SectionWrapper>
  );
}

